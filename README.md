<h1>Online Store</h1>
<p>A modern e-commerce web application built with Angular frontend and ASP.NET Core backend.</p>
<h2>Features</h2>
<ul>
  <li>Authentication forms</li>
  <li>Persistent shopping cart</li>
  <li>Product catalog with search and order by price/name functionality</li>
  <li>Admin panel for product management</li>
</ul>

<h2>Technologies</h2>
<h3>Frontend</h3>
<ul>
  <li>Angular 19</li>
  <li>Typescript</li>
  <li>Angular Material</li>
  <li>Bootstrap</li>
  <li>RxJS</li>
</ul>

<h3>Backend</h3>
<ul>
  <li>ASP.NET Core 9.0</li>
  <li>Entity Framework Core</li>
  <li>RESTful API architecture</li>
  <li>SQLite</li>
</ul>

<h2>Prerequisites</h2>
<ul>
  <li>Node.js (version 16+)</li>
  <li>npm (version 8+)</li>
  <li>.NET 9.0 SDK</li>
  <li>SQLite</li>
</ul>

<h2>Getting Started</h2>
<h3>Backend Setup</h3>

<ol>
  <li>Clone the repository</li>

```bash
clone https://github.com/daria-balaj/online-shop.git
```
  <li>Navigate to the backend directory</li>
  
```bash
cd api
```
  <li>Update the connection string in appsettings.json</li>
  <li>Run database migrations</li>

```bash
dotnet ef database update
```
  <li>Start the backend server</li>
  
```bash
dotnet run
```

The API will be available at https://localhost:7074

</ol>

<h3>Frontend Setup</h3>
<ol>
  <li>Navigate to the frontend directory
    
```bash
cd client
```
  </li>
  
<li>Install dependencies</li>

```bash
npm install
```

<li>Start the development server</li>

```bash
ng serve
```
The application will be available at http://localhost:4200
</ol>



