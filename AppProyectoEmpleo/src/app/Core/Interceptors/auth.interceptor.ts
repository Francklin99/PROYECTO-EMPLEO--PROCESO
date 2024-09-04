import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  // Evitamos interceptar las peticiones de acceso
  if (req.url.includes("Acceso")) return next(req);

  // Verificamos si localStorage está disponible
  let token = '';
  if (typeof localStorage !== 'undefined') {
    token = localStorage.getItem('token') || '';
  }

  const clonRequest = req.clone({
    setHeaders: {
      Authorization: `Bearer ${token}`
    }
  });
  return next(clonRequest);
};
