using AirportWebApi.DAL;
using AirportWebApi.DAL.Models;
using AutoMapper;
using Newtonsoft.Json;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AirportWebApi.BL.Services
{
    public class BaseService
    {
        private IUow repositories;
        public BaseService(IUow uow)
        {
            repositories = uow;
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            //if (typeof(T) == typeof(Flight))
            //    await LetWait(1000);
            return await Task.Run(() => repositories.GetRepository<T>().GetAll());
        }
        public async Task<T> GetById<T>(int id) where T : class
        {
            //if (typeof(T) == typeof(Flight))
            //    await LetWait(1000);
            return await Task.Run(() => repositories.GetRepository<T>().GetById(id));

        }

        public async Task Add<T>(T item) where T : class
        {
            await Task.Run(() => repositories.GetRepository<T>().Add(item));
        }

        public async Task Update<T>(T item) where T : class
        {
            await Task.Run(() => repositories.GetRepository<T>().Update(item));
        }

        public async Task Remove<T>(int id) where T : class
        {
            await Task.Run(() => repositories.GetRepository<T>().Remove(id));
        }

        public async Task SaveChangesAsync()
        {
            await repositories.SaveChangesAsync();
        }

        public async Task GetTen(IMapper mapper)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string response = await client.GetStringAsync("http://5b128555d50a5c0014ef1204.mockapi.io/crew");
            IEnumerable<CrewTenDto> data = JsonConvert.DeserializeObject<IEnumerable<CrewTenDto>>(response);
            List<CrewTenDto> tenCrews = data.Take(10).ToList();

            List<Crew> crews = new List<Crew>();
            List<FlightAttendant> flightAttendants = new List<FlightAttendant>();
            List<Pilot> pilots = new List<Pilot>();

            foreach (var c in tenCrews)
            {

                flightAttendants = mapper.Map<List<FlightAttendant>>(c.Stewardess.ToList());
                pilots = mapper.Map<List<Pilot>>(c.Pilot.ToList());

                crews.Add(new Crew() { Pilot = pilots.First(), FlightAttendants = flightAttendants });

            }
            var t1 = SaveToDb(crews);

            var t2 = Task.Run(() => CrewsWriter(string.Format(@"../Shared/CrewLogs/log" +
                DateTime.Now.ToString("yyyy-dd-M/HH-mm") + ".csv"), crews));

            await Task.WhenAll(t1, t2);
        }

        private async Task CrewsWriter(string path, List<Crew> crews)
        {
            StringBuilder sb;
            int i = 1;
            using (StreamWriter file = new StreamWriter(path))
            {
                foreach (var crew in crews)
                {
                    sb = new StringBuilder();
                    sb.AppendLine();
                    sb.Append("---Crew---(" + i + ") \n");
                    sb.AppendLine();
                    sb.AppendLine("Pilot");
                    sb.Append(string.Format("Name: {0}, Surname:{1}, Birthday:{2} \n",
                        crew.Pilot.Name, crew.Pilot.Surname, crew.Pilot.Birthday, crew.Pilot.Experience));
                    sb.AppendLine("Stewardess:");
                    await file.WriteAsync(sb.ToString());
                    foreach (var stewardess in crew.FlightAttendants)
                        await file.WriteLineAsync(string.Format("Name: {0}, Surname:{1}, Birthday:{2}",
                            stewardess.Name, stewardess.Surname, stewardess.Birthday));
                    sb.AppendLine();
                    i++;
                }
            }

        }
        private async Task SaveToDb(List<Crew> crews)
        {
            repositories.GetRepository<Crew>().SetAll(crews);
            await SaveChangesAsync();
        }

        private Task LetWait(int time)
        {
            Timer t = new Timer(time);
            TaskCompletionSource<int> tsource = new TaskCompletionSource<int>();
            t.Start();
            t.Elapsed += (o, e) =>
            {
                try
                {
                    tsource.SetResult(time);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    tsource.SetException(ex);
                }

            };
            return tsource.Task;
        }
    }

}
