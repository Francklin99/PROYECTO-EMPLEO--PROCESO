import { Component, inject } from '@angular/core';
import { AccesoService } from '../../Core/Services/acceso.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators,ReactiveFormsModule } from '@angular/forms';

//para angular material
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';

import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [MatCardModule,MatFormFieldModule,MatInputModule,MatButtonModule,ReactiveFormsModule],
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.css',
  providers: [DatePipe]
})
export default class RegistroComponent {

  private accesoService=inject(AccesoService);
  private router=inject(Router);
  public formBuild=inject(FormBuilder);
  private datePipe=inject(DatePipe);

  public formCuenta:FormGroup=this.formBuild.group({
    usuario: this.formBuild.group({
      username:['',Validators.required],
      email:['',Validators.required],
      passwordHash:['',Validators.required],
    }),
    persona: this.formBuild.group({
      userId:[0],
      firstName:['',Validators.required],
      lastName:['',Validators.required],
      dateOfBirth:['',Validators.required],
      address:['',Validators.required],
      phoneNumber:['',Validators.required]
    })
  });



  registrarCuenta(){
    if(this.formCuenta.invalid)return;

    // Convertir la fecha al formato deseado
    const formValue = this.formCuenta.value;
    formValue.persona.dateOfBirth = this.datePipe.transform(formValue.persona.dateOfBirth, 'yyyy/MM/dd');


    // Imprimir el objeto que se va a enviar
  console.log("Objeto enviado al servidor:", formValue);

    this.accesoService.registrarcuenta(this.formCuenta.value).subscribe({
      next:(data)=>{
        if(data.status){
          alert("Cuenta registrada");
          this.router.navigate(['login']);
        }
        else{
          alert("Cuenta no registrada");
        }
      },
      error:(error)=>{
        console.log(error);
      }
    })
  }

  volver(){
    this.router.navigate(['login']);
  }

}
