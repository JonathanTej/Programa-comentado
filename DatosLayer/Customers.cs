public class Customers
{
    // Identificador único del cliente
    public string CustomerID { get; set; }

    // Nombre de la compañía del cliente
    public string CompanyName { get; set; }

    // Nombre del contacto principal en la compañía
    public string ContactName { get; set; }

    // Título del contacto principal (por ejemplo, Gerente, Director)
    public string ContactTitle { get; set; }

    // Dirección física de la compañía
    public string Address { get; set; }

    // Ciudad donde se encuentra la compañía
    public string City { get; set; }

    // Región o estado donde se encuentra la compañía
    public string Region { get; set; }

    // Código postal de la dirección de la compañía
    public string PostalCode { get; set; }

    // País donde se encuentra la compañía
    public string Country { get; set; }

    // Número de teléfono del cliente
    public string Phone { get; set; }

    // Número de fax del cliente
    public string Fax { get; set; }
}
