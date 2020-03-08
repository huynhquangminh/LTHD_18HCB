// import { WebStorageKey } from './../globlas/WebStorageKey';
// import { Injectable } from '@angular/core';

// @Injectable({
//   providedIn: 'root'
// })
// export class WebstorageService {

//   constructor(
//     private localSt: LocalStorageService,
//     private sessionSt: SessionStorageService
//   ) {

//   }

//   /**
//    * storeLocalStorage
//    * @param key key
//    * @param data data
//    */
//   storeLocalStorage(key: WebStorageKey, data: any) {
//     this.localSt.store(key, data);
//   }

//   /**
//    * storeSessionStorage
//    * @param key key
//    * @param data data
//    */
//   storeSessionStorage(key: WebStorageKey, data: any) {
//     this.sessionSt.store(key, data);
//   }

//   /**
//    * getLocalStorage
//    * @param key key
//    */
//   getLocalStorage(key: WebStorageKey) {
//     return this.localSt.retrieve(key)
//       ;
//   }

//   /**
//    * getSessionStorage
//    * @param key key
//    */
//   getSessionStorage(key: WebStorageKey) {
//     return this.sessionSt.retrieve(key)
//       ;
//   }

//   /**
//    * getSessionStorage
//    * @param key key
//    */
//   getSessionStorageAsObserve(key: WebStorageKey) {
//     return this.sessionSt.observe(key)
//       ;
//   }

//   /**
//    * removeLocalStorage
//    * @param key key
//    */
//   removeLocalStorage(key: WebStorageKey) {
//     this.localSt.clear(key)
//       ;
//   }

//   /**
//    * removeSessionStorage
//    * @param key key
//    */
//   removeSessionStorage(key: WebStorageKey) {
//     this.sessionSt.clear(key)
//       ;
//   }

//   sessionClear() {
//     this.sessionSt.clear();
//   }

//   localClear() {
//     this.localSt.clear();
//   }
// }
