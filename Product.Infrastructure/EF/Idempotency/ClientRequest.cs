﻿namespace Product.Infrastructure.EF.Idempotency;
public class ClientRequest

{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Time { get; set; }
}
