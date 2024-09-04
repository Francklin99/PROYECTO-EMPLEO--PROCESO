import { inject, PLATFORM_ID } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AccesoService } from '../Services/acceso.service';
import { catchError, map, of } from 'rxjs';
import { isPlatformBrowser } from '@angular/common';

// Definimos el guardia de rutas como una función que implementa CanActivateFn
export const authGuard: CanActivateFn = (route, state) => {
  // Inyectamos las dependencias necesarias
  const platformId = inject(PLATFORM_ID);  // Identificador de la plataforma (navegador o servidor)
  const router = inject(Router);  // Servicio de enrutamiento para redireccionar
  const accesoService = inject(AccesoService);  // Servicio para validar el token

  // Verificamos si estamos en el navegador (cliente) y no en el servidor
  if (isPlatformBrowser(platformId)) {
    // Intentamos obtener el token de localStorage
    const token = localStorage.getItem('token') || '';  // Obtenemos el token, si existe

    // Verificamos si el token no está vacío
    if (token !== '') {
      // Llamamos al servicio para validar el token
      return accesoService.validarToken(token).pipe(
        // Procesamos la respuesta de la validación del token
        map(data => {
          if (data.isSuccess) {
            // Si el token es válido, permitimos el acceso a la ruta
            return true;
          } else {
            // Si el token no es válido, redirigimos a la página principal (inicio)
            router.navigate(['']);
            return false;
          }
        }),
        // Manejamos posibles errores en la validación
        catchError(error => {
          // En caso de error, redirigimos a la página principal (inicio)
          router.navigate(['']);
          return of(false);  // Devolvemos un observable que emite 'false'
        })
      );
    } else {
      // Si no hay token, redirigimos a la página de inicio de sesión
      router.navigate(['login']);
      return of(false);  // Devolvemos un observable que emite 'false'
    }
  } else {
    // Si estamos en el servidor, no podemos acceder a localStorage
    return of(false);  // Devolvemos un observable que emite 'false'
  }
};
