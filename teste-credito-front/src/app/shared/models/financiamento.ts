export class Financiamento {
    public Valor!: number | null;
    public Tipo!: string | null;
    public QuantidadeParcelas!: number | null;
    public DataPrimeiraParcela!: Date | null;
    public ValorJuros!: number | null;
    public Status!: string | null;

    constructor(){
    }
}