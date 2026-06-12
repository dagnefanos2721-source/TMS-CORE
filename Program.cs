//Console.WriteLine("Hello world!");
/*string? region =null;
//Console.WriteLine(region.ToUpper());
string? upperRegion = region?.ToUpper();
Console.WriteLine($"Region (conditional): {upperRegion}");
region ??= "Addis Ababa";
Console.WriteLine($"Region (assigned): {region}");*/

//Declare Your First TMS Variables
/*string studentName = "Abeba";
string studentId = "STU-001";
int enrollmentCount = 3;
decimal grantAmount = 1999.99m; // 'm' suffix marks a decimal literal
DateTime enrolledAt = DateTime.UtcNow;
string? campusRegion = null;
Console.WriteLine($"Student: {studentName} ({studentId})");
Console.WriteLine($"Courses: {enrollmentCount}");
Console.WriteLine($"Grant: {grantAmount:F2}");
Console.WriteLine($"Enrolled: {enrolledAt:yyyy-MM-dd}");
Console.WriteLine($"Campus: {campusRegion ?? "Not assigned"}");*/

// Legacy implementation — the bug that caused the audit failure
/*double grantPerStudent = 1999.99;
double totalAllocation = grantPerStudent * 100_000;
Console.WriteLine($"Total allocated (double): {totalAllocation}");
*/

//Replace the calculation with the decimal type:
/*decimal grantPerStudent = 1999.99m;
decimal totalAllocation = grantPerStudent * 100_000m;
Console.WriteLine($"Total allocated (decimal): {totalAllocation}");
Console.WriteLine($"Total allocated (formatted): {totalAllocation:F3}");
*/
// Legacy implementation — what the logging service did to the data
/*public class Enrollment
{
public string StudentId { get; set; } = string.Empty;
public string CourseCode { get; set; } = string.Empty;
public DateTime ProcessedAt { get; set; }
}
// Somewhere in the logging pipeline:
// enrollment.CourseCode = null; // ← No compiler error. Data silently corrupted.*/


/*var enrollment = new EnrollmentRecord("STU-001", "CS-401", DateTime.UtcNow);
Console.WriteLine(enrollment);
// Try to mutate it — uncomment this line and see the compiler error:
//enrollment.CourseCode = "HACKED"; // ERROR: init-only property
// Non-destructive copy — creates a NEW record with one field changed
var corrected = enrollment with { CourseCode = "CS-402" };
Console.WriteLine(corrected);
// Value equality — two records with the same data are equal
var duplicate = new EnrollmentRecord("STU-001", "CS-401", enrollment.EnrolledAt);
Console.WriteLine($"Same data? {enrollment == duplicate}"); // True*/

var course = new Course { Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
Console.WriteLine($"Course: {course.Title} (Capacity: {course.Capacity})");
// Invalid capacity — should throw
try
{
course.Capacity = -5;
}
catch (ArgumentOutOfRangeException ex)
{
Console.WriteLine($"Caught: {ex.Message}");
}
// Invalid title — should throw
try
{
course.Title = "";
}
catch (ArgumentException ex)
{
Console.WriteLine($"Caught: {ex.Message}");
}

//new result
var s = new Student { Id = "S1", Name = "Abeba", Age = 20, GPA = 3.8m };
Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");
// These should throw — try each one:
// new Student { Id = "S2", Name = "", Age = 20, GPA = 3.0m };
// new Student { Id = "S3", Name = "Test", Age = 12, GPA = 3.0m };
// new Student { Id = "S4", Name = "Test", Age = 20, GPA = 5.0m };
void PrintGradeReport(IEnumerable<IGradable> assessments)
{
Console.WriteLine("--- Grade Report ---");
foreach (var item in assessments)
{
Console.WriteLine($"{item.Title}: {item.CalculateGrade():F2}%");
}
}
IGradable[] cohortAssessments = [
new Quiz { Title = "C# Basics", CorrectAnswers = 18, TotalQuestions = 20 },
new LabAssignment { Title = "Registration API", FunctionalityScore = 90m, CodeQualityScore =
85m }
];
PrintGradeReport(cohortAssessments);