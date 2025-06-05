import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { ClientUserResponse } from '../models/client-user-response.model';

@Injectable({
  providedIn: 'root'
})
export class ClientUserService {

  private apiUrl = 'http://localhost:5115/api/ClientUser';

  constructor(private http: HttpClient, private router: Router) { }

  getClientUsers(): Observable<ClientUserResponse[]> {
    return this.http.get<ClientUserResponse[]>(`${this.apiUrl}/GetClientUsers`);
  }

  getClientUserById(id: number): Observable<ClientUserResponse> {
    return this.http.get<ClientUserResponse>(`${this.apiUrl}/GetClientUserById/${id}`);
  }
}
