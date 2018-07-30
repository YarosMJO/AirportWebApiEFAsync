using AirportWebApi.DAL;
using AirportWebApi.DAL.Models;
using AirportWebApi.DAL.Repositories;
using FakeItEasy;
using System;

namespace AirportWebApi.Tests
{
    class FakeUnitOfWork : IUow
    {
        private AirportContext context;

        public FakeUnitOfWork(AirportContext context)
        {
            this.context = context;
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            if (typeof(T) == typeof(Flight))
            {
                var fake = A.Fake<IRepository<Flight>>();
                A.CallTo(() => fake.Add(A<Flight>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<Flight>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Flight>>();
            }
            else if (typeof(T) == typeof(Crew))
            {
                var fake = A.Fake<IRepository<Crew>>();
                A.CallTo(() => fake.Add(A<Crew>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<Crew>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Crew>>();
            }
            else if (typeof(T) == typeof(Departure))
            {
                var fake = A.Fake<IRepository<Departure>>();
                A.CallTo(() => fake.Add(A<Departure>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<Departure>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Departure>>();
            }
            else if (typeof(T) == typeof(Pilot))
            {
                var fake = A.Fake<IRepository<Pilot>>();
                A.CallTo(() => fake.Add(A<Pilot>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<Pilot>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Pilot>>();
            }
            else if (typeof(T) == typeof(Plane))
            {
                var fake = A.Fake<IRepository<Plane>>();
                A.CallTo(() => fake.Add(A<Plane>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<Plane>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Plane>>();
            }
            else if (typeof(T) == typeof(PlaneType))
            {
                var fake = A.Fake<IRepository<PlaneType>>();
                A.CallTo(() => fake.Add(A<PlaneType>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<PlaneType>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<PlaneType>>();
            }
            else if (typeof(T) == typeof(FlightAttendant))
            {
                var fake = A.Fake<IRepository<FlightAttendant>>();
                A.CallTo(() => fake.Add(A<FlightAttendant>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<FlightAttendant>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<FlightAttendant>>();
            }
            else if (typeof(T) == typeof(Ticket))
            {
                var fake = A.Fake<IRepository<Ticket>>();
                A.CallTo(() => fake.Add(A<Ticket>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<Ticket>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Ticket>>();
            }
            else
            {
                throw new TypeAccessException("Wrong type of repo");
            }
        }

        public void SaveChanges() { }

    }
}
