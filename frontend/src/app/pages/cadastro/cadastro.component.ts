import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
})
export class CadastroComponent {
  cadastroForm: FormGroup;
  senhaInvalida: boolean = false;
  showPassword: boolean = false;
  showConfirmPassword: boolean = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.cadastroForm = this.fb.group({
      userName: [''],
      userFullName: [''],
      email: ['', [Validators.email]],
      password: [''],
      confirmPassword: [''],
      telefone: [''],
      cpf: [''],
      cnpj: [''],
      accountType: [0]
    });
  }

  cadastrar() {
    const senha = this.cadastroForm.get('password')?.value;
    const confirmacao = this.cadastroForm.get('confirmPassword')?.value;

    if (senha !== confirmacao) {
      this.senhaInvalida = true;
      return;
    } else {
      this.senhaInvalida = false;
    }

    console.log(this.cadastroForm.value);

    if (this.cadastroForm.valid) {
      this.authService.cadastrar(this.cadastroForm.value).subscribe(() => {
        alert('Cadastro realizado com sucesso!');
        this.router.navigate(['/login']);
      });
    }
  }

  togglePasswordVisibility(): void {
    this.showPassword = !this.showPassword;
  }

  toggleConfirmPasswordVisibility(): void {
    this.showConfirmPassword = !this.showConfirmPassword;
  }

  get f(): { [key: string]: AbstractControl } {
    return this.cadastroForm.controls;
  }

  navegarParaHome() {
    this.router.navigate(['/']);
  }
}
