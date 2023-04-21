using System;

namespace exercise_6.Abstract;

[Serializable]
public class Post
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }

    public override string ToString() => $"User {UserId} posted a post ({Id}): {Title} - {Body}";
}