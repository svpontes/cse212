public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
            throw new InvalidOperationException("No one in the queue.");

        Person person = _people.Dequeue();

        // Infinite turns (0 or negative)
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // More than one turn left
        else if (person.Turns > 1)
        {
            person.Turns--;
            _people.Enqueue(person);
        }
        // Turns == 1: last turn -> do NOT requeue

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
