package com.uni.lista1.models;

import jakarta.persistence.*;

@Entity
public class KlientUsluga {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @ManyToOne
    private Klient klient;

    @ManyToOne
    private Usluga usluga;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Klient getKlient() {
        return klient;
    }

    public void setKlient(Klient klient) {
        this.klient = klient;
    }

    public Usluga getUsluga() {
        return usluga;
    }

    public void setUsluga(Usluga usluga) {
        this.usluga = usluga;
    }

    // Data powiązania klienta z usługą, jeśli potrzebne

    // Getters and Setters
}
