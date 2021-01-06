import {Inject, Injectable} from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackBarService {
  constructor(private snackBar: MatSnackBar){
  }

  openErrorSnackBar(message: string): void {
    this.snackBar.open(message, 'Закрыть', {
      panelClass: ['warn']
    });
  }
}
