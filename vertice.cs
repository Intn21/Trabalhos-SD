/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace ClienteServidor
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class vertice : TBase
  {
    private int _nome;
    private int _cor;
    private string _descricao;
    private double _peso;

    public int Nome
    {
      get
      {
        return _nome;
      }
      set
      {
        __isset.nome = true;
        this._nome = value;
      }
    }

    public int Cor
    {
      get
      {
        return _cor;
      }
      set
      {
        __isset.cor = true;
        this._cor = value;
      }
    }

    public string Descricao
    {
      get
      {
        return _descricao;
      }
      set
      {
        __isset.descricao = true;
        this._descricao = value;
      }
    }

    public double Peso
    {
      get
      {
        return _peso;
      }
      set
      {
        __isset.peso = true;
        this._peso = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool nome;
      public bool cor;
      public bool descricao;
      public bool peso;
    }

    public vertice() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.I32) {
                Nome = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.I32) {
                Cor = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                Descricao = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.Double) {
                Peso = iprot.ReadDouble();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("vertice");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.nome) {
          field.Name = "nome";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Nome);
          oprot.WriteFieldEnd();
        }
        if (__isset.cor) {
          field.Name = "cor";
          field.Type = TType.I32;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Cor);
          oprot.WriteFieldEnd();
        }
        if (Descricao != null && __isset.descricao) {
          field.Name = "descricao";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Descricao);
          oprot.WriteFieldEnd();
        }
        if (__isset.peso) {
          field.Name = "peso";
          field.Type = TType.Double;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteDouble(Peso);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("vertice(");
      bool __first = true;
      if (__isset.nome) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Nome: ");
        __sb.Append(Nome);
      }
      if (__isset.cor) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Cor: ");
        __sb.Append(Cor);
      }
      if (Descricao != null && __isset.descricao) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Descricao: ");
        __sb.Append(Descricao);
      }
      if (__isset.peso) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Peso: ");
        __sb.Append(Peso);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
