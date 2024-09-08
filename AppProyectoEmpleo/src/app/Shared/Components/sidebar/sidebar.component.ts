import { Component, inject } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {

  private router = inject(Router);
  BuscarEmpleo(){
    this.router.navigate(['/buscarempleo']);
  }

  MiPerfil(){
    this.router.navigate(['/miperfil']);
  }

}
