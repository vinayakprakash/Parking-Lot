import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/auth';
import * as firebase from 'firebase/app';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AuthService {
  constructor(public afAuth: AngularFireAuth, private httpClient: HttpClient) {}

  doGoogleLogin() {
    return new Promise<any>((resolve, reject) => {
      const provider = new firebase.auth.GoogleAuthProvider();
      provider.addScope('profile');
      provider.addScope('email');
      this.afAuth.auth.signInWithPopup(provider).then(
        res => {
          resolve(res);
          this.setToken();
        },
        err => {
          console.log(err);
          reject(err);
        }
      );
    });
  }

  doRegister(value) {
    return new Promise<any>((resolve, reject) => {
      firebase
        .auth()
        .createUserWithEmailAndPassword(value.email, value.password)
        .then(
          res => {
            resolve(res);
          },
          err => reject(err)
        );
    });
  }

  doLogin(value) {
    return new Promise<any>((resolve, reject) => {
      firebase
        .auth()
        .signInWithEmailAndPassword(value.email, value.password)
        .then(
          res => {
            resolve(res);
            this.setToken();
          },
          err => reject(err)
        );
    });
  }

  doLogout() {
    return new Promise((resolve, reject) => {
      if (firebase.auth().currentUser) {
        this.afAuth.auth.signOut();
        resolve();
      } else {
        reject();
      }
    });
  }

  setToken() {
    firebase
      .auth()
      .currentUser.getIdToken()
      .then(data => sessionStorage.setItem('token', data));
  }

  setUserProfile() {
    return this.httpClient
      .get('https://localhost:5001/api/parkinglot/profile', {
        responseType: 'text'
      })
      .subscribe(data => {
        console.log(data);
        sessionStorage.setItem('profile', data.toString());
      });
  }
}
