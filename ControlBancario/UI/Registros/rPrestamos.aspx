<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPrestamos.aspx.cs" Inherits="ControlBancario.UI.Registros.rPrestamos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function openReportModal() {
            $("#<%=reportModal.ClientID%>").modal({
                backdrop: 'static',
                keyboard: false
            });
            $("#<%=reportModal.ClientID%>").modal("show");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
        <!--Card Header-->
        <div class="card-header text-center text-white bg-success">
            <h3>Registro de prestamos</h3>
        </div>

        <!--Card body-->
        <div class="card-body">

            <!--Id-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label4" CssClass="col-lg-2 col-form-label" Text="PrestamoId" runat="server">PrestamoId:</asp:Label>
                <div class="col-lg-4">

                    <asp:TextBox ID="PrestamosIdTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary" runat="server" CausesValidation="False">
                        <span class="fas fa-search"></span>
                        Buscar
                    </asp:LinkButton>
                </div>
            </div>

            <!--Fecha-->          
          <div class="form-group row justify-content-center">
                <asp:Label ID="Label12" CssClass="col-lg-2 col-form-label" Text="Fecha" runat="server">Fecha:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="FechaTextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">

                </div>
            </div>

        <!--CuentaId-->
        <div class="form-group row justify-content-center">
            <asp:Label ID="Label5" CssClass="col-lg-2 col-form-label" Text="Cuenta" runat="server">Cuenta:</asp:Label>
            <div class="col-lg-4">
                <asp:DropDownList ID="CuentaDropDownList" CssClass="form-control" runat="server">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CuentaDropDownList" runat="server" Text="*" Display="Dynamic" ErrorMessage="Debes seleccionar una cuenta bancaria"></asp:RequiredFieldValidator>
            </div>
        </div>


         <%--Capital--%>
        <div class="form-group row justify-content-center">
            <asp:Label ID="Label3" CssClass="col-lg-2 col-form-label" Text="Capital" runat="server">Capital:</asp:Label>
            <div class="col-lg-4">
                <asp:TextBox ID="CapitalTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
            </div>
        </div>
             <div class="col-lg-4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CuentaDropDownList" runat="server" Text="*" Display="Dynamic" ErrorMessage="Debes ingresar un capital"></asp:RequiredFieldValidator>
            </div>
    </div>


    <!--Interes anual-->
    <div class="form-group row justify-content-center">
        <asp:Label ID="Label6" CssClass="col-lg-2 col-form-label" Text="Interes" runat="server">Interes:</asp:Label>
        <div class="col-lg-4">
            <div class="input-group">
                <asp:TextBox ID="InteresTextBox" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                <div class="input-group-append">
                    <span class="input-group-text">%</span>
                </div>
            </div>
        </div>
        <div class="col-lg-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="InteresTextBox" Text="*" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar una tasa de interes"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator" ControlToValidate="InteresTextBox" runat="server" Display="Dynamic" Text="*" ErrorMessage="El interes no es valido" Type="Integer" MinimumValue="0" MaximumValue="999999"></asp:RangeValidator>
        </div>
    </div>

    <!--Tiempo-->
    <div class="form-group row justify-content-center">
        <asp:Label ID="Label7" CssClass="col-lg-2 col-form-label" Text="Tiempo" runat="server">Tiempo:</asp:Label>
        <div class="col-lg-4">
            <asp:TextBox ID="TiempoTextBox" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TiempoTextBox" Text="*" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar el tiempo de pago"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator4" ControlToValidate="TiempoTextBox" runat="server" Display="Dynamic" Text="*" ErrorMessage="El tiempo no es valido" Type="Integer" MinimumValue="0" MaximumValue="999999"></asp:RangeValidator>
        </div>
        <div class="w-100"></div>
        <div class="col-lg-1">
            <asp:LinkButton ID="CalcularLinkButton" CssClass="btn btn-primary" Text="text" runat="server" CausesValidation="true" OnClick="CalcularLinkButton_Click">
                        <span class=""></span>             
                        Calcular
            </asp:LinkButton>
        </div>
    </div>

    <!--Grid-->
    <div class="row justify-content-center mt-3">
        <div class="col-lg-11">
            <asp:GridView ID="CuotaGridView" runat="server" AllowPaging="true" PageSize="7" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="NoCuota" HeaderText="No Cuota" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Interes" HeaderText="Interes" />
                    <asp:BoundField DataField="Capital" HeaderText="Capital" />
                    <asp:BoundField DataField="Balance" HeaderText="Balance" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="form-group row justify-content-center">
        <div class="col-lg-2 mr-2">
            <asp:TextBox ID="TotalTextBox" CssClass="form-control" Visible="false" ReadOnly="true" runat="server"></asp:TextBox>
        </div>
        </div>
       <%-- <div class="col-lg-2 mr-3">
            <asp:TextBox ID="CapitalTotalTextBox" CssClass="form-control" Visible="false" ReadOnly="true" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-2 ml-5 mr-1">
        </div>
    </div>--%>

    <!--Card body end-->
    </div>

         <div class="card-footer">
             <!--Butones-->
             <div class="form-group row justify-content-center">
                  <!--Nuevo-->
                <div class="col-lg-1 mr-1">
                    <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-primary" runat="server" CausesValidation="False" OnClick="NuevoLinkButton_Click">
                        <span class="fas fa-plus"></span>
                        Nuevo
                    </asp:LinkButton>
                </div>

                 <!--Guardar-->
                 <div class="col-lg-1 mr-3">
                     <asp:LinkButton ID="GuardarLinkButton" CssClass="btn btn-success" runat="server" OnClick="GuardarLinkButton_Click">
                        <span class="fas fa-save"></span>
                        Guardar
                     </asp:LinkButton>
                 </div>

                 <!--Eliminar-->
                 <div class="col-lg-1 mr-3">
                     <asp:LinkButton ID="EliminarLinkButton" CssClass="btn btn-danger" runat="server" CausesValidation="False" OnClick="EliminarLinkButton_Click">
                        <span class="fas fa-trash-alt"></span>
                        Eliminar
                     </asp:LinkButton>
                 </div>

                 <!--Imprimir-->
                 <div class="col-lg-1 mr-3">
                     <asp:LinkButton ID="ImprimirLinkButton" CssClass="btn btn-warning" runat="server" CausesValidation="False" OnClick="ImprimirLinkButton_Click">
                        <span class="fas fa-print"></span>
                        Imprimir
                     </asp:LinkButton>
                 </div>
             </div>

             <!--Card footer end-->
         </div>
    <%--</div>--%>

    <!--Report Modal-->
    <div class="modal fade" id="reportModal" role="dialog" runat="server">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <!--Body-->
                  <%--<div class="modal-body">
                    <rsweb:reportviewer ID="PrestamoReportViewer" Width="100%" runat="server">
                        <ServerReport ReportPath=""  ReportServerUrl=""/>
                    </rsweb:reportviewer>
                </div>--%>

                <!--Footer-->
                <div class="modal-footer">
                    <button class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <asp:ValidationSummary ID="ValidationSummary" ShowMessageBox="true" ShowSummary="false" runat="server" />
</asp:Content>
