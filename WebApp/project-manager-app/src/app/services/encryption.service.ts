import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, tap } from 'rxjs';
import { Project } from '../shared/project';
import { Task } from '../shared/task';
import { GlobalConstants } from '../shared/global-constants';
import { AuthService } from './auth.service';
import { ProfileService } from './profile.service';
import * as CryptoJS from 'crypto-js';

@Injectable({
  providedIn: 'root',
})
export class EncryptionService {
  private key = 'b14ca5898a4e4133bbce2ea2315a1916';

  encrypt(value: string): string {
    return CryptoJS.AES.encrypt(value, this.key).toString();
  }

  decrypt(textToDecrypt: string): string {
    return CryptoJS.AES.decrypt(textToDecrypt, this.key, {
      keySize: 128 / 8,
      mode: CryptoJS.mode.CBC,
      padding: CryptoJS.pad.Pkcs7,
    }).toString(CryptoJS.enc.Utf8);
  }
}
