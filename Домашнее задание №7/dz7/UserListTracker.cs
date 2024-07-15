using System;
using dz7.model;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Collections.ObjectModel;

namespace dz7
{
    internal class UserListTracker : IObserver<ObservableCollection<User>>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ObservableCollection<User> value)
        {
            throw new NotImplementedException();
        }
    }
}
