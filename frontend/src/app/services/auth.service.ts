import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5115/api/Auth';

  constructor(private http: HttpClient, private router: Router) { }

  cadastrar(dados: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, dados);
  }

  login(dados: any): Observable<any> {
    console.log(dados);
    debugger;
    return this.http.post(`${this.apiUrl}/login`, dados).pipe(
      map((res: any) => {
        console.log(res);
        localStorage.setItem('token', res.token);
        this.router.navigate(['/eventpage']);
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  estaLogado(): boolean {
    return !!localStorage.getItem('token');
  }
}
