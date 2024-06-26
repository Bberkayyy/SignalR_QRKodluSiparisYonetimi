﻿namespace SignalR_WebUI.Dtos.OrderDetailDtos;

public class CreateOrderDetailDto
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int ProductCount { get; set; }
    public decimal UnitPrice = 0;
    public decimal TotalPrice = 0;
}