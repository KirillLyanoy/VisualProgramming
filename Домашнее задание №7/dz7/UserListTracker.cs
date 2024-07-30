using System;
using System.Reactive.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using dz7.model;

namespace dz7
{
      internal class UserListTracker
      {
        public IObservable<NotifyCollectionChangedEventArgs> FactoryMethod<T>(ObservableCollection<T> collection)
        {
            IObservable<NotifyCollectionChangedEventArgs> observable = ChangeArgs(collection);

            observable.Subscribe(e =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        User newUser = e.NewItems[0] as User;
                        SaveLog($"Добавлен объект {newUser.Name}");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        User oldUser = e.OldItems[0] as User;
                        SaveLog($"Удалён объект \"{oldUser.Name}\"");
                        break;
                    default:
                        break;
                }
            });
            return observable;
        }        
        IObservable<NotifyCollectionChangedEventArgs> ChangeArgs<T>(ObservableCollection<T> collection)
        {
            return Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
               h => collection.CollectionChanged += h, h => collection.CollectionChanged -= h)
               .Select(x => x.EventArgs);     
        }
        void SaveLog(string changes)
        {
            StreamWriter fs = new StreamWriter("D://log.txt", true);            
            fs.WriteLine(changes);
            fs.Close();
        }
      }   
}
