<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCuentas.aspx.cs" Inherits="ControlBancario.UI.Registros.rCuentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">

        <div class="card-header text-center text-white bg-primary">
            <h3>Registro de Cuentas</h3>
        </div>

        <div class="card-body">
            <!--Id-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label1" CssClass="col-lg-2 col-form-label" Text="CuentaId" runat="server">CuentaId:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="IdTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary" runat="server" CausesValidation="False" OnClick="BuscarLinkButton_Click">
                        <span class="fas fa-search"></span>
                        Buscar
                    </asp:LinkButton>
                </div>
            </div>

            <!--Fecha-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label2" CssClass="col-lg-2 col-form-label" Text="Fecha" runat="server">Fecha:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="FechaTextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">

                </div>
            </div>

            <!--Nombre-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label3" CssClass="col-lg-2 col-form-label" Text="Nombre" runat="server">Nombre:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="NombreTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator" ControlToValidate="NombreTextBox" runat="server" Display="Dynamic" Text="*" ErrorMessage="Indique un nombre de cuenta"></asp:RequiredFieldValidator>
                </div>
            </div>

            <!--Balance-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label4" CssClass="col-lg-2 col-form-label" Text="Balance" runat="server">Balance:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="BalanceTextBox" CssClass="form-control" ReadOnly="true" TextMode="Number" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>

            <!--Card body end-->
        </div>

        <div class="card-footer">
            <!--B0tones-->
            <div class="form-group">
                <div class="col-lg-2 mr-3"">
                    <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-primary" runat="server" CausesValidation="False" OnClick="NuevoLinkButton_Click">
                        <span class="fas fa-plus"></span>
                        Nuevo
                    </asp:LinkButton>
                </div>
                <div class="text-center">
                    <asp:LinkButton ID="GuardarLinkButton" CssClass="btn btn-primary" runat="server" OnClick="GuardarLinkButton_Click" >
                        <span class="fas fa-save"></span>
                        Guardar
                    </asp:LinkButton>
                </div>
                <div class="col-lg-1 mr-3">
                    <asp:LinkButton ID="EliminarLinkButton" CssClass="btn btn-primary" runat="server" CausesValidation="False" OnClick="EliminarLinkButton_Click">
                        <span class="fa fa-trash-alt"></span>
                        Eliminar
                    </asp:LinkButton>
                </div>      
            </div>

            <!--Card footer end-->
        </div>
    </div>
     <asp:ValidationSummary ID="ValidationSummary" ShowMessageBox="true" ShowSummary="false" runat="server" />
</asp:Content>