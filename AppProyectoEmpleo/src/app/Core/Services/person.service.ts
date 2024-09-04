import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appSettings } from '../../Settings/appsettings';
import { Observable } from 'rxjs';
import { ResponseApi } from '../Interfaces/ResponseApi';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private http=inject(HttpClient);
  private baseUrl:string = appSettings.apiUrl + 'Persona/';
  constructor() { }

  lista():Observable<ResponseApi>{
    return this.http.get<ResponseApi>(this.baseUrl + 'Lista');
  }
}
