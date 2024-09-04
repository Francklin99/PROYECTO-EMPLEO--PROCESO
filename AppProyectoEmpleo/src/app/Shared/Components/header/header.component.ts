import { Component, AfterViewInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'] // Corregido: styleUrls
})
export class HeaderComponent implements AfterViewInit {

  ngAfterViewInit() {
    setTimeout(() => {
      const modal = document.getElementById('myModal');
      const btn = document.getElementById('btn-perfil');
      const span = document.querySelector('.close') as HTMLElement;

      console.log(modal, btn, span); // Verificar si se encuentran los elementos

      if (btn && modal && span) {
        btn.onclick = function() {
          modal.style.display = 'block';
        };

        span.onclick = function() {
          modal.style.display = 'none';
        };

        window.onclick = function(event) {
          if (event.target === modal) {
            modal.style.display = 'none';
          }
        };
      } else {
        console.error('One or more elements are null:', { modal, btn, span });
      }
    }, 0);
  }

}
