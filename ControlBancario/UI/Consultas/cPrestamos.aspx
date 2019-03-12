<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cPrestamos.aspx.cs" Inherits="ControlBancario.UI.Consultas.cPrestamos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-header text-center text-white bg-primary">
            <h3>Consulta de pretasmos</h3>
        </div>

        <!--Card body-->
        <div class="card-body">
            <!--Rango fecha-->
            <div class="form-group row justify-content-center">
                <div class="col-lg-4">
                    <asp:Label ID="Label1" runat="server" Text="Fecha-inicio">Desde:</asp:Label>
                    <asp:TextBox ID="FInicialTextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-2"></div>
                <div class="col-lg-4">
                    <asp:Label ID="Label2" runat="server" Text="Fecha-inicial">Hasta:</asp:Label>
                    <asp:TextBox ID="FFinalTextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
            </div>


            <!---->
            <div class="row justify-content-center">
                <div class="col-lg-4">
                    <asp:Label ID="FiltroLabel" runat="server" Text="Filtrar-por">
                        Filtro:
                    </asp:Label>
                    <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>PrestamoId</asp:ListItem>
                        <asp:ListItem>CuentaId</asp:ListItem>
                        <asp:ListItem>Fecha</asp:ListItem>
                        <asp:ListItem>Capital</asp:ListItem>
                        <asp:ListItem>Interes</asp:ListItem>
                        <asp:ListItem>Tiempo</asp:ListItem>
                        <asp:ListItem>Total</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-4">
                    <asp:Label ID="BuscarLabel" runat="server" Text="Buscar">Buscar:</asp:Label>
                    <asp:TextBox ID="BuscarTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary mt-4" runat="server">
                        <span class="fas fa-search"></span>
                        Buscar
                    </asp:LinkButton>
                </div>
            </div>

            <!--Grid-->
            <div class="row justify-content-center mt-3">
                <div class="col-lg-11">
                    <asp:GridView ID="PrestamoGridView" runat="server" AllowPaging="true" PageSize="7" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False" OnPageIndexChanging="PrestamoGridView_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="PrestamosId" HeaderText="PrestamosId" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                            <asp:BoundField DataField="CuentaId" HeaderText="CuentaId" />
                            <asp:BoundField DataField="Capital" HeaderText="Capital" />
                            <asp:BoundField DataField="Interes" HeaderText="Interes" />
                            <asp:BoundField DataField="Tiempo" HeaderText="Tiempo" />
                            <asp:BoundField DataField="Total" HeaderText="Total" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="ButtonImprimir" class="form-control btn btn-primary btn-sm" runat="server" Text="Imprimir Reporte" OnClick="ButtonImprimir_Click" />
                    </div>
                </div>
            </div>

            <!--Card body end-->
        </div>
    </div>
</asp:Content>
