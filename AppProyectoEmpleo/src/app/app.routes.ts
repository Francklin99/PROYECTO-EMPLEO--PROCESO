import { Routes } from '@angular/router';
import LoginComponent from './Pages/login/login.component';
import RegistroComponent from './Pages/registro/registro.component';
import InicioComponent from './Business/inicio/inicio.component';
import { HomeComponent } from './Pages/home/home.component';
import { authGuard } from './Core/Guards/auth.guard';
import { BuscarEmpleoComponent } from './Business/buscar-empleo/buscar-empleo.component';
import { MiPerfilComponent } from './Business/mi-perfil/mi-perfil.component';


export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'registro', component: RegistroComponent },
  { path: 'inicio', component: InicioComponent,canActivate:[authGuard] },
  {path:'buscarempleo', component: BuscarEmpleoComponent,canActivate:[authGuard] },
  {path:'miperfil', component: MiPerfilComponent,canActivate:[authGuard] },
];
