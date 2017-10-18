<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarPrecio.aspx.cs" Inherits="WcfTallerAutomatizacionCasosPrueba.Calcular" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Buscar Precio</title>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../../dist/css/bootstrap-theme.min.css" rel="stylesheet"/>
</head>
<body>
   <div class="container">
    <h1></h1>
    
        <div class="row">
        <div class="col-sm-8">
          <div class="panel panel-primary">
            <div class="panel-heading">
              <h3 class="panel-title">Búsqueda de Precios</h3>
            </div>
            <div class="panel-body">
                    <form id="form1" runat="server">

        Ingrese el nombre del producto: <asp:TextBox ID="tbxProducto" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar"  class="btn btn-lg btn-default"/><br />
        <asp:Label ID="lblPrecioEs" runat="server" Text="El precio es: " Visible="false" ></asp:Label>
        <asp:Label ID="lblRespuesta" runat="server" Text="" Font-Bold="true" class="alert alert-success"></asp:Label>
        <asp:Label ID="lblTiempo" runat="server" Text=""></asp:Label>
    </form>              
            </div>
          </div>
        </div>
    
        
    </div>

       </div>
</body>
</html>
