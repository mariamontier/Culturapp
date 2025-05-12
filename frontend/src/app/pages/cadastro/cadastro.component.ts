import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
})
export class CadastroComponent {

  cadastroForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.cadastroForm = this.fb.group({
      userName: [''],          // Nome de usuário
      userFullName: [''],      // Nome completo
      email: [''],             // E-mail
      password: [''],          // Senha
      cpf: [''],               // CPF
      cnpj: [''],              // CNPJ
      accountType: [0],        // Tipo de conta, default 0 (Pessoa Física)
    });
  }

  cadastrar() {
    if (this.cadastroForm.valid) {
      this.authService.cadastrar(this.cadastroForm.value).subscribe(() => {
        this.router.navigate(['/login']);
      });
    }
  }
}
