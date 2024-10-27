import { PedidoItemViewModel } from "./pedido-item.vm";

export class PedidoViewModel {
    id: string;
    clienteId: string;
    clienteNome: string;
    codigo: number;
    status: number;
    data: string;
    valorTotal: number;
    itens: PedidoItemViewModel[];
}