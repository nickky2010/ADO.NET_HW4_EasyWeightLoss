# ADO.NET - Home work 4
***

Написать реализации интерфейса
```C#
public interface IRepository<T>:IDisposable where T :class
    {
        void Create(T item);
        T FindById(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);
    }
```
для сущностей модели `User`, `Product`, `Role` с использованием `ADO` (подключенный режим).

Дополнительное задание: реализовать интерфейс с использованием `Dapper`.
