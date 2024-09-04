import { Component } from '@angular/core';
import { SidebarComponent } from "../../Shared/Components/sidebar/sidebar.component";
import { HeaderComponent } from '../../Shared/Components/header/header.component';

@Component({
  selector: 'app-inicio',
  standalone: true,
  imports: [SidebarComponent, HeaderComponent],
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export default class InicioComponent {

}
