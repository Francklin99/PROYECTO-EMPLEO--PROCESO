import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appSettings } from '../../Settings/appsettings';
import { Cuenta } from '../../Core/Interfaces/Cuenta';
import { Observable } from 'rxjs';
import { ResponseApi } from '../Interfaces/ResponseApi';
import { Login } from '../Interfaces/Login';
import { ResponseAcceso } from '../Interfaces/ResponseAcceso';



@Injectable({
  providedIn: 'root'
})
export class AccesoService {

  private http=inject(HttpClient);
  private baseUrl:string = appSettings.apiUrl + 'Acceso/';


  constructor() { }

  registrarcuenta(objeto:Cuenta): Observable<ResponseApi>{
    return this.http.post<ResponseApi>(this.baseUrl + 'RegistrarCuenta',objeto);
  }

  login(objeto:Login): Observable<ResponseAcceso>{
    return this.http.post<ResponseAcceso>(this.baseUrl + 'Login',objeto);
  }

  validarToken(token:string): Observable<ResponseAcceso>{
    return this.http.get<ResponseAcceso>(`${this.baseUrl}ValidarToken?token=${token}`);

  }
  // Método para cerrar sesión

}
