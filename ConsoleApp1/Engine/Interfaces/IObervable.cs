using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Interfaces
{
    interface IObervable
    {
        void addObserver();

        void deleteObserver();
        void notifyObservers();
        void setChanged();
    }
}
