using System;

namespace exercise_6.Abstract;

[Serializable]
public class Todo
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool Completed { get; set; }

    private static string FormatCompleted(bool completed) => completed ? "Completed" : "Incomplete";

    public override string ToString() => $"User {UserId} with task {Id} ({FormatCompleted(Completed)}): {Title}";
}