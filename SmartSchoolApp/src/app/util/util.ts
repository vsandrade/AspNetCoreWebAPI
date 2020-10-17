export class Util {
  static nomeConcat(item: any[]): string {
    return item.map(x => x.nome).join(',');
  }
}
