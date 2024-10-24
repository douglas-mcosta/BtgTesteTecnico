namespace BTG.Core.Communication
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            Errors = new ReponseErroMessages();
        }

        public string Title { get; set; }
        public int Status { get; set; }
        public ReponseErroMessages Errors { get; set; }
    }

    public class ReponseErroMessages
    {
        public ReponseErroMessages()
        {
            Mensagens = new List<string>();
        }

        public List<string> Mensagens { get; set; }
    }
}
