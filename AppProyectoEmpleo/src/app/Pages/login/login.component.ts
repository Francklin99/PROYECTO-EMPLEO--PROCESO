import { Component, inject } from '@angular/core';
import { AccesoService } from '../../Core/Services/acceso.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators,ReactiveFormsModule } from '@angular/forms';
import { Login } from '../../Core/Interfaces/Login';

//para angular material
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatCardModule,MatFormFieldModule,MatInputModule,MatButtonModule,ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export default class LoginComponent {

  private accesoService=inject(AccesoService);
  private router=inject(Router);
  public formBuild=inject(FormBuilder);

  public formLogin:FormGroup=this.formBuild.group({
    email:['',Validators.required],
    passwordHash:['',Validators.required]
  });

  iniciarSesion(){

    if(this.formLogin.invalid)return;

      const objeto:Login={
        email:this.formLogin.value.email,
        passwordHash:this.formLogin.value.passwordHash
      }

      this.accesoService.login(objeto).subscribe({
        next:(data)=>{
          if(data.isSuccess){
            localStorage.setItem('token',data.token);
            this.router.navigate(['buscarempleo']);
          }
          else{
            alert("Credenciales incorrectas");
          }

        },
        error:(error)=>{
          alert(error.message);
        }
      })

  }

  registrarse(){
    this.router.navigate(['registro']);
  }

}
