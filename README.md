<!--Titulo principal-->
<div id="user-content-toc">
  <ul align="center">
    <summary>
      <!--Titulo-->
      <h2 style="display: inline-bloc">Sistema de Punto de Venta</h2>
      <br>
      <!--Divizor horizontal (gradiant)-->
      <img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif">
      </summary>
    </ul>
  </div>
  
<div id="user-content-toc">
  <!--Caso de estudio-->
  <h3>Caso de estudio:</h3>
  <p align="justify">
    Desarrollar un sistema de punto de venta bajo la arquitectura cliente-servidor, para un negocio de la localidad del ramo de perfumería. El negocio cuenta con un Administrador que requiere urgentemente de una herramienta que le permita llevar la administración del negocio. Para ello ha solicitado los servicios de un estudiante de la carrera de sistemas para el desarrollo del proyecto bajo los siguientes requerimientos -sistema a instalar en computadora personal con Windows, interfaz gráfica, fácil instalación y funcionalidad abajo descrita-.
  </p>
</div>

<div id="user-content-toc">
  <!--Funcionalidad del Sistema de Control de Ventas-->
  <h3>Funcionalidad del Sistema de Control de Ventas:</h3>
  <p align="justify">
    El sistema para desarrollar contará con los siguientes módulos:
  </p>
  <p>
    <ins>Autenticación del Usuario</ins>
  </p>
  <p align="justify">
    Contar con un formulario con el logotipo del negocio, y solicitar el usuario y contraseña, validando dichos datos en el sistema, permitiendo hacer cambios de contraseña.
  </p>
  <p>
    <ins>Menú Principal</ins>
  </p>
  <p>
    El sistema debe presentar un menú principal con el logotipo del negocio y presentar opciones para:
  </p>
  <ol>
     <li>Clientes del negocio.</li>
     <li>Productos</li>
     <li>Ventas de Contado</li>
     <li>Ventas de Crédito</li>
     <li>Control de pagos parciales en ventas de crédito</li>
     <li>Reportes financieros</li>
  </ol>
</div>

<div>
  <p>
    <ins>Control de Clientes</ins>
  </p>
  <p align="justify">
    El sistema contará con funcionalidad para:
  </p>
  <ul>
    <li>El registro de nuevos clientes con sus datos generales como nombre, dirección, teléfono, y el sistema le asignará un número de cliente único.</li>
    <li>Reporte del padrón de clientes ordenados alfabéticamente, mostrando el nombre completo, dirección, teléfono y el número de cliente.</li>
  </ul>
</div>

<div>
  <p>
    <ins>Control de Productos</ins>
  </p>
  <p align="justify">
    El sistema debe permitir:
  </p>
  <ul>
    <li>El registro de nuevos productos con su descripción, cantidad de piezas, precio de compra, precio de venta. Los nuevos productos actualizarán el inventario del negocio.</li>
    <li>La búsqueda de productos con base al filtro de la descripción completa o parte de ella, mostrando la descripción, precio de compra y precio de venta.</li> 
  </ul>
</div>

<div>
  <p>
    <ins>Ventas de Contado</ins>
  </p>
  <p align="justify">
    Debe contar con la funcionalidad para:
  </p>
  <ul>
    <li>Localizar al cliente con base al filtro del nombre o parte del nombre, mostrando la dirección y teléfono.</li>
    <li>Una vez localizado el cliente permitirá realizar la venta de productos registrando los productos vendidos que incluya descripción, cantidad, precio de venta y calcular el monto total de la compra.</li>
    <li>Al finalizar la venta se asigna un folio único de venta, el sistema expide el ticket con todos los datos anteriores (datos del cliente, fecha venta, el detalle de todos los productos y el monto total de la venta).</li>
    <li>Al finalizar la venta debe actualizar el inventario del negocio, restando los productos vendidos.</li>
  </ul>
</div>

<div>
  <p>
    <ins>Ventas a Crédito</ins>
  </p>
  <p align="justify">
    Permitirá al negocio facilitar salida de productos a los clientes, mismos que serán registrados en el sistema. 
  </p>
  <ul>
    <li>Localizar al cliente con base al filtro del nombre o parte del nombre, mostrando la dirección y teléfono.</li>
    <li>Una vez localizado el cliente permitirá realizar la venta de productos registrando los productos vendidos que incluya descripción, cantidad, precio de venta y calcular el monto total de la compra.</li>
    <li>Al finalizar la venta se asigna un folio único de venta, el sistema expide el ticket con todos los datos anteriores (datos del cliente, fecha venta, el detalle de todos los productos y el monto total de la venta).</li>
    <li>Al finalizar la venta debe actualizar el inventario del negocio, restando los productos vendidos.</li>
    <li>El cliente puede aportar un abono inicial y el resto se toma como pago pendiente.</li>
    <li>En este caso el sistema debe permitir señalar productos pagados para marcar en la relación y distinguirlos del resto.</li>
    <li>Permitir regresar productos para reintegrarlos al inventario</li>
    <li>Añadir nuevos productos recalculando el nuevo monto excluyendo los productos ya pagados y regresados.</li>
    <li>En caso de pagos pendientes el sistema debe permitir realizar más pagos parciales al préstamo hasta su liquidación total.</li>
  </ul>
</div>

<div>
  <p>
    <ins>Administración del Negocio</ins>
  </p>
  <p align="justify">
    El sistema debe permitir al Administrador del negocio obtener reportes de las ventas realizadas, tanto de préstamo como de contado.
  </p>
  <ul>
    <li>El filtro de búsqueda puede ser con base a un rango de fechas o por nombre del cliente.</li>
    <li>La información que mostrar debe incluir el nombre del cliente, folio de la venta, fecha de la venta, monto total de la venta y el gran total que corresponde al total acumulado en el período o rango de fechas indicado.</li>
    <li> En el caso de filtro por ventas de crédito mostrar la suma de los pagos parciales realizados si es que los hubiera.</li>
  </ul>
</div>
