import { Component, AfterViewInit, inject, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import {MatIconModule} from '@angular/material/icon';
import { UserService } from '../../../Core/Services/user.service';
import { CommonModule } from '@angular/common';
import { User } from '../../../Core/Interfaces/User';


@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterOutlet, MatIconModule,CommonModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'] // Corregido: styleUrls
})
export class HeaderComponent implements AfterViewInit,OnInit {


user:User | null=null;
private userService = inject(UserService);
private router = inject(Router);

ngOnInit(): void {
    this.userService.getUserInfo().subscribe((data)=>{
      this.user = data.value;
    })
}


  ngAfterViewInit() {
    setTimeout(() => {
      const modal = document.getElementById('myModal');
      const btn = document.getElementById('btn-perfil');

      console.log(modal, btn); // Verificar si se encuentran los elementos

      if (btn && modal) {
        btn.onclick = function() {
          modal.style.display = 'block';
        };

        window.onclick = function(event) {
          if (event.target === modal) {
            modal.style.display = 'none';
          }
        };
      } else {
        console.error('One or more elements are null:', { modal, btn});
      }
    }, 0);
  }

  logout() {
    localStorage.removeItem('token'); // Remueve el token del localStorage
    this.router.navigate(['/login']); // Redirige al usuario a la página de login
  }

}
