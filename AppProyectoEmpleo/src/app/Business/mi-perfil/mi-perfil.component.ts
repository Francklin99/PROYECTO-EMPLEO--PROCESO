import { Component } from '@angular/core';
import { SidebarComponent } from "../../Shared/Components/sidebar/sidebar.component";
import { HeaderComponent } from '../../Shared/Components/header/header.component';

@Component({
  selector: 'app-mi-perfil',
  standalone: true,
  imports: [SidebarComponent, HeaderComponent],
  templateUrl: './mi-perfil.component.html',
  styleUrl: './mi-perfil.component.css'
})
export class MiPerfilComponent {

}
