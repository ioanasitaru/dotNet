export class EventDTO {
  constructor(
    public id : string,
    public name: string,
    public description: string,
    public dateAndTime:  Date,
    public location: string,
    public image: string,
    public tags: Array<string>
  ) {}

}
