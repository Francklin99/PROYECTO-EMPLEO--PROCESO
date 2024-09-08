import { AfterViewInit, Component } from '@angular/core';
import { SidebarComponent } from "../../Shared/Components/sidebar/sidebar.component";
import { HeaderComponent } from '../../Shared/Components/header/header.component';
import { filter } from 'rxjs';
@Component({
  selector: 'app-buscar-empleo',
  standalone: true,
  imports: [SidebarComponent, HeaderComponent],
  templateUrl: './buscar-empleo.component.html',
  styleUrl: './buscar-empleo.component.css'
})
export class BuscarEmpleoComponent implements AfterViewInit{



  ngAfterViewInit(): void {
    setTimeout(() => {
      const filter1 = document.getElementById('button-filter-1');
      const viewfilter1 = document.getElementById('filter-1');

      if (filter1 && viewfilter1) {
        filter1.onclick = function () {
          // Verifica el estado de la propiedad `display`
          if (viewfilter1.classList.contains('active')) {
            // Si está visible, lo oculta
            viewfilter1.classList.remove('active');
          } else {
            // Si está oculto, lo muestra
            viewfilter1.classList.add('active');
          }
        }
      }
    }, 0);
  }


}
