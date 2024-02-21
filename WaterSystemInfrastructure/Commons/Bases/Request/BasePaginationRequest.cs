namespace WaterSystem.Infrastructure.Commons.Bases.Request
{
    public class BasePaginationRequest
    {
        public int NumPage { get; set; } = 1;//numero de paginas a paginar
        public int NumRecordsPage { get; set; } = 10; //Mostrar 10 registro por paginas si queremos

        public readonly int NumMaxRecordPage = 50; //numero maximo de paginas que queremos mostrar
        public string Order { get; set; } = "asc"; //el orden que qeuremo darle default asc
        public string? Sort { get; set; } = null;  //Campo que queremos ordenar
        public int Records
        {

            get => NumMaxRecordPage;
            set
            {
                NumRecordsPage = value > NumMaxRecordPage ? NumMaxRecordPage : value;
            }
        }

    }
}
