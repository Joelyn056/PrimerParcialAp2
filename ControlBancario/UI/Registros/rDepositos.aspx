<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rDepositos.aspx.cs" Inherits="ControlBancario.UI.Registros.rDepositos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-header text-center text-white bg-primary">
            <h3>Registro de Depositos</h3>
        </div>

        <!--Card body-->
        <div class="card-body">
            <!--Id-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label1" CssClass="col-form-label" Text="DepositoId" runat="server">DepositoId:</asp:Label>
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

            <!--CuentaId-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label5" CssClass="col-form-label" Text="Cuentas" runat="server">Cuenta:</asp:Label>
                <div class="col-lg-4">
                    <asp:DropDownList ID="CuentaDropDownList" CssClass="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CuentaDropDownList" Text="*" runat="server" ErrorMessage="Debe seleccionar"></asp:RequiredFieldValidator>
                </div>
            </div>

            <!--Fecha-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label2" CssClass="col-form-label" Text="Fecha" runat="server">Fecha:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="FechaTextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>

            <!--Concepto-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label4" CssClass="col-form-label" Text="Concepto" runat="server">Concepto:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="ConceptoTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ConceptoTextBox" Text="*" runat="server" Display="Dynamic" ErrorMessage="Indique un concepto"></asp:RequiredFieldValidator>
                </div>
            </div>

            <!--Monto-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label6" CssClass="col-form-label" Text="Monto" runat="server">Monto:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="MontoTextBox" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <asp:RangeValidator ID="RangeValidator" ControlToValidate="MontoTextBox" runat="server" Display="Dynamic" Text="*" ErrorMessage="Ingrese un monto positivo" Type="Integer" MinimumValue="0" MaximumValue="999999"></asp:RangeValidator>
                </div>
            </div>

            <!--Card body end-->
        </div>

        <div class="card-footer">
            <!--Butones-->
            <div class="form-group row justify-content-center">
                <div class="col-lg-1 mr-1">
                    <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-primary" runat="server" CausesValidation="False" OnClick="NuevoLinkButton_Click">
                        <span class="fas fa-plus"></span>
                        Nuevo
                    </asp:LinkButton>
                </div>
                <div class="col-lg-1 mr-3">
                    <asp:LinkButton ID="GuardarLinkButton" CssClass="btn btn-primary" runat="server" OnClick="GuardarLinkButton_Click">
                        <span class="fas fa-save"></span>
                        Guardar
                    </asp:LinkButton>
                </div>
                <div class="col-lg-1 mr-3">
                    <asp:LinkButton ID="EliminarLinkButton" CssClass="btn btn-primary" runat="server" CausesValidation="False">
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


