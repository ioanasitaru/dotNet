export class User {
  constructor(
    public name: string,
    public email: string,
    public location: string,
    public username: string,
    public password: string,
    public confirmPassword: string,
    public tags: Array<string>
  ) {}

}
