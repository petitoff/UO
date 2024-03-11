package com.uni.lista1.models;

import jakarta.persistence.*;

@Entity
public class Konto {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    private String nrKonta;

    @ManyToOne
    private Klient klient;

    private Double saldo;

    @ManyToOne
    private RodzajKonta rodzaj;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getNrKonta() {
        return nrKonta;
    }

    public void setNrKonta(String nrKonta) {
        this.nrKonta = nrKonta;
    }

    public Klient getKlient() {
        return klient;
    }

    public void setKlient(Klient klient) {
        this.klient = klient;
    }

    public Double getSaldo() {
        return saldo;
    }

    public void setSaldo(Double saldo) {
        this.saldo = saldo;
    }

    public RodzajKonta getRodzaj() {
        return rodzaj;
    }

    public void setRodzaj(RodzajKonta rodzaj) {
        this.rodzaj = rodzaj;
    }

    // Getters and Setters
}
