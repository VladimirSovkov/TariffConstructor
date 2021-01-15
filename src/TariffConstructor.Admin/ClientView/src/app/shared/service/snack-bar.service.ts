import {Inject, Injectable} from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackBarService {
  constructor(private snackBar: MatSnackBar){
  }

  openErrorHttpSnackBar(error: any): void {
    let message = '';
    if (error instanceof ProgressEvent) {
      message = 'Не удается подключиться к серверу';
    }
    else {
      message = error;
    }
    this.snackBar.open(message, 'Закрыть', {
      panelClass: ['warn']
    });
  }
}
