import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appSettings } from '../../Settings/appsettings';
import { Observable } from 'rxjs';
import { ResponseApi } from '../Interfaces/ResponseApi';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private http = inject(HttpClient);
  private baseUrl = appSettings.apiUrl + 'User/';

  constructor() { }

  getUserInfo(): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(this.baseUrl + 'GetUserInfo');
  }
}
