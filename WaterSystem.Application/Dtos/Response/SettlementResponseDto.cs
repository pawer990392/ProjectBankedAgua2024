namespace WaterSystem.Application.Dtos.Response
{
    public class SettlementResponseDto
    {
        //Es loq eu quermeo smostrar al modo ISS es decir el interfaz o el consumidor 
        public int IdSettlement { get; set; }

        public string? Name { get; set; } = null!;

        public DateTime CreateDate { get; set; }

    }
}
