namespace interview_tallertechnologies.Application.UseCases.User.v1.Queries
{
    public class GetUserByUserNameQueryResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
