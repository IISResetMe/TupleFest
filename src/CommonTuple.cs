using System.Collections;

namespace TupleFest;

public abstract class CommonTuple {

    public IEnumerator GetEnumerator() {
        List<object?> list = [];
        Traverse(list.Add);
        return list.GetEnumerator();
    }

    public abstract void Traverse(Action<object?> action);
}
