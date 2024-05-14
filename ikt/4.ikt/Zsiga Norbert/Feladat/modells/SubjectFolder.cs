using System.Text;

public class SubjectFolder
    {
    public int StudentId { get; set; }

    public Dictionary<string, ICollection<int>> Subjects { get; set; }

    public SubjectFolder() { }

    public SubjectFolder(int studentId, Dictionary<string, ICollection<int>> subjectsAndMarks)
    {
        StudentId = studentId;
        Subjects = subjectsAndMarks;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var subject in Subjects)
        { 
            sb.AppendLine($"{subject.Key}: ");
            foreach (var mark in subject.Value)
            { 
                sb.AppendLine($"\t-{mark}");
            }
        }
        return sb.ToString();
    }
}

